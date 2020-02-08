using Kernel.Extensions;
using EntityFramework.Data;
using EntityFramework.Validations;
using EntityFramework.Resources;
using TPDomain.Models;
using TPDomain.Services;
using TPDomain.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TPDomainTests.Services
{
    [TestClass]
    public class DeveloperServiceTests : BaseServiceTests
    {
        private readonly IDeveloperService _developerService;

        public DeveloperServiceTests()
        {
            _developerService = new DeveloperService(
                new Repository(_dbContext),
                new DataAnnotationValidator()
            );
        }

        [TestMethod]
        public void AddRequiredPropertyEmptyShouldReturnValidationException()
        {
            var developer = new Developer();

            Assert.ThrowsException<ValidationException>
                (() => _developerService.Add(developer));
        }

        [TestMethod]
        public void AddExistentDevShouldReturnRecordFoundExceptionMessage()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };
            _developerService.Add(developer);

            var exception = Assert.ThrowsException<Exception>
                (() => _developerService.Add(developer));

            Assert.AreEqual(exception.Message, 
                typeof(DataMessages).GetMessage("ErrorMessage_RecordFound"));
        }

        [TestMethod]
        public void AddRepeatedEmailShouldReturnDbUpdateException()
        {
            var developer1 = new Developer
            {
                Name = "Name1",
                City = "City1",
                State = "State1",
                Skype = "Skype1",
                Whatsapp = "Whatsapp1",
                Salary = 111.11M,
                Email = "email@email.com"
            };
            _developerService.Add(developer1);

            var developer2 = new Developer
            {
                Name = "Name2",
                City = "City2",
                State = "State2",
                Skype = "Skype2",
                Whatsapp = "Whatsapp2",
                Salary = 222.22M,
                Email = "email@email.com"
            };

            Assert.ThrowsException<DbUpdateException>
                (() => _developerService.Add(developer2));
        }

        [TestMethod]
        public void AddWithSuccess()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };

            int affectedRows = _developerService.Add(developer);

            Assert.AreEqual(1, affectedRows);
            Assert.IsTrue(developer.DeveloperId > 0);
        }

        [TestMethod]
        public void GetNonexistentDev()
        {
            int id = -1;

            var developer = _developerService.Get(id);

            Assert.IsNull(developer);
        }

        [TestMethod]
        public void GetWithSuccess()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };
            _developerService.Add(developer);

            var developerWithGet = _developerService.Get(developer.DeveloperId);

            Assert.AreEqual(developerWithGet, developer);
        }

        [TestMethod]
        public void GetDevelopers()
        {
            var developers = new List<Developer>
            {
                new Developer
                {
                    Name = "Name1",
                    City = "City1",
                    State = "State1",
                    Skype = "Skype1",
                    Whatsapp = "Whatsapp1",
                    Salary = 111.11M,
                    Email = "email1@email.com"
                },
                new Developer
                {
                    Name = "Name2",
                    City = "City2",
                    State = "State2",
                    Skype = "Skype2",
                    Whatsapp = "Whatsapp2",
                    Salary = 222.22M,
                    Email = "email2@email.com"
                },
                new Developer
                {
                    Name = "Name3",
                    City = "City3",
                    State = "State3",
                    Skype = "Skype3",
                    Whatsapp = "Whatsapp3",
                    Salary = 333.33M,
                    Email = "email3@email.com"
                },
            };
            developers.ForEach(dev => _developerService.Add(dev));

            var developersWithGet = _developerService.GetDevelopers();

            Assert.IsTrue(
                developers.All(dev => developersWithGet.Contains(dev))
                && developers.Count == developersWithGet.Count
            );
        }

        [TestMethod]
        public void DeleteNonexistentDevShouldReturnRecordNotFoundExceptionMessage()
        {
            int id = -1;

            var exception = Assert.ThrowsException<Exception>
                (() => _developerService.Delete(id));

            Assert.AreEqual(exception.Message, 
                typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
        }

        [TestMethod]
        public void DeleteWithSuccess()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };
            _developerService.Add(developer);
            int id = developer.DeveloperId;

            int affectedRows = _developerService.Delete(id);
            developer = _developerService.Get(id);

            Assert.AreEqual(1, affectedRows);
            Assert.IsNull(developer);
        }

        [TestMethod]
        public void UpdateRequiredPropertyEmptyShouldReturnValidationException()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };
            _developerService.Add(developer);

            TestRequiredProperty(nameof(developer.Name), null);

            TestRequiredProperty(nameof(developer.City), null);

            TestRequiredProperty(nameof(developer.State), null);

            TestRequiredProperty(nameof(developer.Skype), null);

            TestRequiredProperty(nameof(developer.Whatsapp), null);

            TestRequiredProperty(nameof(developer.Salary), decimal.Zero);

            TestRequiredProperty(nameof(developer.Email), null);

            void TestRequiredProperty(string propertyName, object emptyValue)
            {
                object propertyValue = typeof(Developer).GetProperty(propertyName)
                    .GetValue(developer);

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, emptyValue);

                var exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Update(developer));

                Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(propertyName)));

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, propertyValue);
            }
        }

        [TestMethod]
        public void UpdateNonexistentDevShouldReturnRecordNotFoundExceptionMessage()
        {
            var developer = new Developer
            {
                DeveloperId = -1,
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };

            var exception = Assert.ThrowsException<Exception>
                (() => _developerService.Update(developer));

            Assert.AreEqual(exception.Message, 
                typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
        }

        [TestMethod]
        public void UpdateRepeatedEmailShouldReturnDbUpdateException()
        {
            var developer1 = new Developer
            {
                Name = "Name1",
                City = "City1",
                State = "State1",
                Skype = "Skype1",
                Whatsapp = "Whatsapp1",
                Salary = 111.11M,
                Email = "email1@email.com"
            };
            _developerService.Add(developer1);

            var developer2 = new Developer
            {
                Name = "Name2",
                City = "City2",
                State = "State2",
                Skype = "Skype2",
                Whatsapp = "Whatsapp2",
                Salary = 222.22M,
                Email = "email2@email.com"
            };
            _developerService.Add(developer2);

            developer2.Email = developer1.Email;

            Assert.ThrowsException<DbUpdateException>
                (() => _developerService.Update(developer2));
        }

        [TestMethod]
        public void UpdateWithSuccess()
        {
            var developer = new Developer
            {
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };
            _developerService.Add(developer);

            developer.Name = "Name2";
            developer.Email = "email2@email.com";
            int affectedRows = _developerService.Update(developer);
            var developerWithGet = _developerService.Get(developer.DeveloperId);

            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual(developerWithGet.Name, "Name2");
            Assert.AreEqual(developerWithGet.Email, "email2@email.com");
        }
    }
}
