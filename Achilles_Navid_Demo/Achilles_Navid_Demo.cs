using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Models;
using PersonDb; 

namespace Achilles_Navid_Demo
{
    public class Achilles_Navid_Demo
    {
        private readonly PersonRepository personRepository;

        public Achilles_Navid_Demo(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }


        [FunctionName("Achilles_Navid_Demo")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "achilles")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Navid_Demo")]
        public async Task<IActionResult> Run1(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "navid")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Person person = JsonConvert.DeserializeObject<Person>(requestBody);

            personRepository.SavePerson(person);

            string responseMessage = string.IsNullOrEmpty(person.Name)
                ? $"Achilles is {person.Age}"
                : $"Hello, {person.Name}, that man is {person.Age}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}

