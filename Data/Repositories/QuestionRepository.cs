using System.Collections.Generic;
using Capital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace Capital.Data.Repositories
{
    /*public class QuestionRepository
    {
        private readonly List<Question> _questions; // Replace this with your actual data source (e.g., Cosmos DB)

        public QuestionRepository()
        {
            // Initialize the questions list or connect to the database
            _questions = new List<Question>();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            // Implement logic to retrieve all questions from the data source
            return _questions;
        }

        public Question GetQuestionById(int id)
        {
            // Implement logic to retrieve a question by id from the data source
            return _questions.Find(q => q.Id == id);
        }

        public void AddQuestion(Question question)
        {
            // Implement logic to add a new question to the data source
            _questions.Add(question);
        }

        public void UpdateQuestion(Question question)
        {
            // Implement logic to update an existing question in the data source
            var existingQuestion = _questions.Find(q => q.Id == question.Id);
            if (existingQuestion != null)
            {
                // Update properties of the existing question
                existingQuestion.Text = question.Text;
                // Update other properties as needed
            }
        }

        public void DeleteQuestion(int id)
        {
            // Implement logic to delete a question from the data source
            var questionToRemove = _questions.Find(q => q.Id == id);
            if (questionToRemove != null)
            {
                _questions.Remove(questionToRemove);
            }
        }
    }*/

    public class QuestionRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        public QuestionRepository(Microsoft.Azure.Cosmos.Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var sqlQuery = "SELECT * FROM c";
            var queryDefinition = new QueryDefinition(sqlQuery);
            var questions = new List<Question>();

            var iterator = _container.GetItemQueryIterator<Question>(queryDefinition);

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                questions.AddRange(response.ToList());
            }

            return questions;
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Question>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task AddQuestionAsync(Question question)
        {
            await _container.CreateItemAsync(question, new PartitionKey(question.Id.ToString()));
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _container.ReplaceItemAsync(question, question.Id.ToString(), new PartitionKey(question.Id.ToString()));
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _container.DeleteItemAsync<Question>(id.ToString(), new PartitionKey(id.ToString()));
        }
    }
}
