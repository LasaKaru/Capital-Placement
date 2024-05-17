using System.Threading.Tasks;

namespace Capital.Models
{
    public interface ICosmosDbService
    {
        Task AddApplicationDataAsync(ApplicationFormData formData);
        Task DeleteApplicationDataAsync(string applicationId);
        Task DeleteCandidateApplicationAsync(string firstName);

        Task CreateApplicationDataAsync(string applicationId);

        Task GetApplicationDataAsync(string applicationId);

        Task UpdateApplicationDataAsync(string applicationId);
        Task CreateCandidateApplicationAsync(ApplicationFormData application);
        //Task UpdateProgramAsync(string id, Program program);
        //Task GetProgramAsync(string id);
        //Task<Program> CreateProgramAsync(Program program);
        //Task<Program> GetProgramAsync(string programTitle);
        // Task<Program> UpdateProgramAsync(string programTitle, Program program);
        //Task DeleteProgramAsync(string programTitle);

        // Methods for CandidateApplication
        //Task<CandidateApplication> CreateCandidateApplicationAsync(CandidateApplication application);
        //Task<CandidateApplication> GetCandidateApplicationAsync(string firstName);
        //Task<CandidateApplication> UpdateCandidateApplicationAsync(string firstName, CandidateApplication application);
        //Task DeleteCandidateApplicationAsync(string firstName);



    }
}