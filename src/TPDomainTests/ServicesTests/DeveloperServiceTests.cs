using Kernel.Extensions;
using EntityFramework.Data;
using EntityFramework.Validations;
using EntityFramework.Resources;
using TPDomain.DataTransferObjects;
using TPDomain.Models;
using TPDomain.Services;
using TPDomain.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TPDomainTests.ServicesTests
{
    [TestClass]
    public class DeveloperServiceTests : BaseServiceTests
    {
        private readonly IDeveloperService _developerService;

        private readonly Availability[] _availabilities =
        {
            new Availability
            {
                AvailabilityId = 1,
                Description = "Up to 4 hours per day / At� 4 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 2,
                Description = "4 to 6 hours per day / De 4 � 6 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 3,
                Description = "6 to 8 hours per day /De 6 � 8 horas por dia"
            }

        };

        private readonly WorkingTime[] _workingTimes =
        {
            new WorkingTime
            {
                WorkingTimeId = 1,
                Description = "Morning (from 08:00 to 12:00) / Manh� (de 08:00 �s 12:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 2,
                Description = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 �s 18:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 3,
                Description = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)"
            }

        };

        private int GetAllRows()
        {
            return 1 + _availabilities.Length + _workingTimes.Length;
        }

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
                    (() => _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes }));

                Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(propertyName)));

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, propertyValue);
            }

            var exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = Array.Empty<Availability>(), WorkingTimes = _workingTimes }));
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
            _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });

            var exception = Assert.ThrowsException<ValidationException>
                (() => _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes }));

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
            _developerService.Add(new DeveloperDto { Developer = developer1, Availabilities = _availabilities, WorkingTimes = _workingTimes });

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
                (() => _developerService.Add(new DeveloperDto { Developer = developer2, Availabilities = _availabilities, WorkingTimes = _workingTimes }));
        }

        [TestMethod]
        public void AddRepeatedAvailabilityShouldReturnDbUpdateException()
        {
            Availability[] availabilities =
            {
                new Availability
                {
                    AvailabilityId = 1,
                    Description = "Up to 4 hours per day / At� 4 horas por dia"
                },
                new Availability
                {
                    AvailabilityId = 1,
                    Description = "Up to 4 hours per day / At� 4 horas por dia"
                }
            };

            var developer = new Developer
            {
                Name = "Name1",
                City = "City1",
                State = "State1",
                Skype = "Skype1",
                Whatsapp = "Whatsapp1",
                Salary = 111.11M,
                Email = "email@email.com"
            };

            Assert.ThrowsException<InvalidOperationException>
                (() => _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = availabilities, WorkingTimes = _workingTimes }));
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

            int affectedRows = _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });

            Assert.AreEqual(GetAllRows(), affectedRows);
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
            _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });

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
            developers.ForEach(dev => _developerService.Add(new DeveloperDto { Developer = dev, Availabilities = _availabilities, WorkingTimes = _workingTimes }));

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

            var exception = Assert.ThrowsException<ValidationException>
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
            _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });
            int id = developer.DeveloperId;

            int affectedRows = _developerService.Delete(id);
            developer = _developerService.Get(id);

            Assert.AreEqual(GetAllRows(), affectedRows);
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
            _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });

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
                    (() => _developerService.Update(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes }));

                Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(propertyName)));

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, propertyValue);
            }

            var exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Update(new DeveloperDto { Developer = developer, Availabilities = Array.Empty<Availability>(), WorkingTimes = _workingTimes }));
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

            var exception = Assert.ThrowsException<ValidationException>
                (() => _developerService.Update(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes }));

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
            _developerService.Add(new DeveloperDto { Developer = developer1, Availabilities = _availabilities, WorkingTimes = _workingTimes });

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
            _developerService.Add(new DeveloperDto { Developer = developer2, Availabilities = _availabilities, WorkingTimes = _workingTimes });

            developer2.Email = developer1.Email;

            Assert.ThrowsException<DbUpdateException>
                (() => _developerService.Update(new DeveloperDto { Developer = developer2, Availabilities = _availabilities, WorkingTimes = _workingTimes }));
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
            _developerService.Add(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });

            developer.Name = "Name2";
            developer.Email = "email2@email.com";
            int affectedRows = _developerService.Update(new DeveloperDto { Developer = developer, Availabilities = _availabilities, WorkingTimes = _workingTimes });
            var developerWithGet = _developerService.Get(developer.DeveloperId);

            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual(developerWithGet.Name, "Name2");
            Assert.AreEqual(developerWithGet.Email, "email2@email.com");
        }
    }
}