using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi1.Models;

namespace MyFirstWebApi1.Controllers
{
    // should be exposed with this route
    // square brackets means take the word below that is paired with controller is placed here
    [Route("api/[controller]")]
    // controller should be exposed as an http api
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // method signature
        // accessible over the internet public
        // granular control
        // explicit: name it well
        // because we want all, we do not need parameters

        List<Animal> _animals = new List<Animal>
        {
            new Animal {Id = 0, Name = "Steve", Type = "Elephant", Weight = 2000},
            new Animal {Id = 1, Name = "George", Type = "Monkey", Weight = 87},
            new Animal {Id = 2, Name = "Tony", Type = "Tiger", Weight = 1200}
        };

        // GET / api/animals
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            // curly brackets mean collection initializer

            return Ok(_animals);
        }

        // GET /api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id)
        {
            // find the first thing in th elist whose id matches the id parameter call
            var animalIWant = _animals.First(a => a.Id == id);

            if (animalIWant == null)
            {
                return NotFound($"Animal with the id {id} was not found.");
            }

            return Ok(animalIWant);
        }

        [HttpPost]
        public IActionResult AddAnAnimal(Animal animalToAdd)
        {
            _animals.Add(animalToAdd);

            return Ok(_animals);
        }

        // PUT /api/animals/{id}
        // this method below me will update something that already exists
        [HttpPut("{id}")]
        public IActionResult UpdateAnAnimal(int id, Animal animal)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == id);

            if (animalToUpdate == null)
            {
                return NotFound("Can't Update cause it doesn't exist");
            }

            animalToUpdate.Name = animal.Name;
            animalToUpdate.Weight = animal.Weight;
            animalToUpdate.Type = animal.Type;

            return Ok(animalToUpdate);
        }
    }
}