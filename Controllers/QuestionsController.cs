using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Capital.Data.Repositories;
using Capital.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capital.DTOs;

namespace Capital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {

        private readonly QuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionsController(QuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            return Ok(questions);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestionDTO questionDTO)
        {
            var question = _mapper.Map<Question>(questionDTO);
            await _questionRepository.AddQuestionAsync(question);

            var createdQuestionDTO = _mapper.Map<QuestionDTO>(question);
            return CreatedAtAction(nameof(Get), new { id = createdQuestionDTO.Id }, createdQuestionDTO);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestionDTO questionDTO)
        {
            if (id != questionDTO.Id)
            {
                return BadRequest();
            }

            var existingQuestion = await _questionRepository.GetQuestionByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            _mapper.Map(questionDTO, existingQuestion);
            await _questionRepository.UpdateQuestionAsync(existingQuestion);

            return NoContent();
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingQuestion = await _questionRepository.GetQuestionByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            await _questionRepository.DeleteQuestionAsync(id);
            return NoContent();
        }
    }
}
