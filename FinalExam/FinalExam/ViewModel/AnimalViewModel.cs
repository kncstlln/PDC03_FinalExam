using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;
using System.IO;
using FinalExam.Model;

using System.Threading.Tasks;

namespace FinalExam.ViewModel
    {
        public class AnimalViewModel
        {
            //Call Database

            private Services.DatabaseContext getContext()
            {
                return new Services.DatabaseContext();
            }

            //Insert Records function

            public int InsertAnimal(Animal obj)
            {
                var _dbContext = getContext();
                _dbContext.Animal.Add(obj);
                int c = _dbContext.SaveChanges();
                return c;
            }

            //Retrieve Records function

            public async Task<List<Animal>> GetAllAnimal()
            {
                var _dbContext = getContext();
                var res = await _dbContext.Animal.ToListAsync();
                return res;
            }

            //Delete Records function

            public int DeleteAnimal(Animal obj)
            {
                var _dbContext = getContext();
                _dbContext.Animal.Remove(obj);
                int c = _dbContext.SaveChanges();
                return c;
            }

            //Update Records
            public async Task<int> UpdateAnimal(Animal obj)
            {
                var _dbContext = getContext();
                _dbContext.Animal.Update(obj);
                int c = await _dbContext.SaveChangesAsync();
                return c;
            }
        }
    }

