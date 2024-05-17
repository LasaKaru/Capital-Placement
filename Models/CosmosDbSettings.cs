using Microsoft.Azure.Cosmos;

namespace Capital.Models
{
    public class CosmosDbSettings
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseName { get; set; }
        public string ContainerName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string AboutYourself { get; set; }
        public int GraduationYear { get; set; }
        public string Keywords { get; set; }
        public bool UKEmbassyRejection { get; set; }
        public int ExperienceYears { get; set; }
        public DateTime MovedToUKDate { get; set; }
    }

    public class CosmosDbService : ICosmosDbService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDbService(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("Capital", "Container1");
        }

        public async Task AddApplicationDataAsync(ApplicationFormData formData)
        {
            await _container.CreateItemAsync(formData);
        }

        public Task CreateApplicationDataAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCandidateApplicationAsync(ApplicationFormData application)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApplicationDataAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCandidateApplicationAsync(string firstName)
        {
            throw new NotImplementedException();
        }

        public Task GetApplicationDataAsync(string applicationId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationDataAsync(string applicationId)
        {
            throw new NotImplementedException();
        }
    }
}
