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
                Description = "Up to 4 hours per day / Até 4 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 2,
                Description = "4 to 6 hours per day / De 4 á 6 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 3,
                Description = "6 to 8 hours per day /De 6 á 8 horas por dia"
            }

        };

        private readonly WorkingTime[] _workingTimes =
        {
            new WorkingTime
            {
                WorkingTimeId = 1,
                Description = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 2,
                Description = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 3,
                Description = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)"
            }

        };

        private readonly KnowledgeDto[] _knowledgeDtos =
        {
            new KnowledgeDto {
                Knowledge = new Knowledge
                {
                    KnowledgeId = 1,
                    Name = "Ionic"
                },
                Rate = 1
            },
            new KnowledgeDto {
                Knowledge = new Knowledge
                {
                    KnowledgeId = 2,
                    Name = "ReactJS"
                },
                Rate = 3
            },
            new KnowledgeDto {
                Knowledge = new Knowledge
                {
                    KnowledgeId = 3,
                    Name = "React Native"
                },
                Rate = 5
            }
        };

        private int GetAllRows()
        {
            return 1 + _availabilities.Length 
                + _workingTimes.Length + _knowledgeDtos.Length;
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
                    (() => _developerService.Add(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = _availabilities,
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = _knowledgeDtos
                    }));

                Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(propertyName)));

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, propertyValue);
            }

            var exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Add(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = Array.Empty<Availability>(),
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = _knowledgeDtos
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(Availability))));

            exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Add(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = _availabilities,
                        WorkingTimes = Array.Empty<WorkingTime>(),
                        KnowledgeDtos = _knowledgeDtos
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(WorkingTime))));

            exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Add(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = _availabilities,
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = Array.Empty<KnowledgeDto>()
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(DeveloperKnowledge.Rate)))
                    + Environment.NewLine +
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(Knowledge))));
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
            _developerService.Add(new DeveloperDto { 
                Developer = developer1, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

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
                (() => _developerService.Add(new DeveloperDto { 
                    Developer = developer2, 
                    Availabilities = _availabilities, 
                    WorkingTimes = _workingTimes,
                    KnowledgeDtos = _knowledgeDtos
                }));
        }

        [TestMethod]
        public void AddRepeatedAvailabilityShouldReturnInvalidOperationException()
        {
            Availability[] availabilities =
            {
                new Availability
                {
                    AvailabilityId = 1,
                    Description = "Up to 4 hours per day / Até 4 horas por dia"
                },
                new Availability
                {
                    AvailabilityId = 1,
                    Description = "Up to 4 hours per day / Até 4 horas por dia"
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
                (() => _developerService.Add(new DeveloperDto { 
                    Developer = developer, 
                    Availabilities = availabilities, 
                    WorkingTimes = _workingTimes }));
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

            int affectedRows = _developerService.Add(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

            Assert.AreEqual(GetAllRows(), affectedRows);
            Assert.IsTrue(developer.DeveloperId > 0);
        }

        [TestMethod]
        public void GetNonexistentDev()
        {
            int id = 1;

            var developerDto = _developerService.GetDeveloperDto(id);

            Assert.IsNull(developerDto.Developer);
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
            _developerService.Add(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

            var developerDto = _developerService.GetDeveloperDto(developer.DeveloperId);

            Assert.AreEqual(developerDto.Developer, developer);
            Assert.IsTrue(
                _availabilities.All(dev => developerDto.Availabilities.Contains(dev))
                && _availabilities.Length == developerDto.Availabilities.Count);
            Assert.IsTrue(
                _workingTimes.All(dev => developerDto.WorkingTimes.Contains(dev))
                && _workingTimes.Length == developerDto.WorkingTimes.Count);
            Assert.IsTrue(
                _knowledgeDtos.All(dev => developerDto.KnowledgeDtos.Contains(dev))
                && _knowledgeDtos.Length == developerDto.KnowledgeDtos.Count);
        }

        [TestMethod]
        public void GetDevelopers()
        {
            Developer[] developers =
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
            Array.ForEach(developers, dev => _developerService.Add(
                new DeveloperDto { 
                    Developer = dev, 
                    Availabilities = 
                    _availabilities, 
                    WorkingTimes = _workingTimes,
                    KnowledgeDtos = _knowledgeDtos
                }));

            var developersWithGet = _developerService.GetDevelopers();

            Assert.IsTrue(
                developers.All(dev => developersWithGet.Contains(dev))
                && developers.Length == developersWithGet.Count
            );
        }

        [TestMethod]
        public void DeleteNonexistentDevShouldReturnRecordNotFoundExceptionMessage()
        {
            int id = 1;

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
            _developerService.Add(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });
            int id = developer.DeveloperId;

            int affectedRows = _developerService.Delete(id);
            var developerDto = _developerService.GetDeveloperDto(id);

            Assert.AreEqual(GetAllRows(), affectedRows);
            Assert.IsNull(developerDto.Developer);
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
            _developerService.Add(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

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
                    (() => _developerService.Update(new DeveloperDto { 
                        Developer = developer, 
                        Availabilities = _availabilities, 
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = _knowledgeDtos
                    }));

                Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(propertyName)));

                typeof(Developer).GetProperty(propertyName)
                    .SetValue(developer, propertyValue);
            }

            var exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Update(new DeveloperDto { 
                        Developer = developer, 
                        Availabilities = Array.Empty<Availability>(), 
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = _knowledgeDtos
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(Availability))));

            exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Update(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = _availabilities,
                        WorkingTimes = Array.Empty<WorkingTime>(),
                        KnowledgeDtos = _knowledgeDtos
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(WorkingTime))));

            exception = Assert.ThrowsException<ValidationException>
                    (() => _developerService.Update(new DeveloperDto
                    {
                        Developer = developer,
                        Availabilities = _availabilities,
                        WorkingTimes = _workingTimes,
                        KnowledgeDtos = Array.Empty<KnowledgeDto>()
                    }));
            Assert.AreEqual(exception.Message,
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(DeveloperKnowledge.Rate)))
                    + Environment.NewLine +
                    typeof(DataMessages).GetMessage("ErrorMessage_Required",
                    typeof(Labels).GetMessage(nameof(Knowledge))));
        }

        [TestMethod]
        public void UpdateNonexistentDevShouldReturnArgumentNullException()
        {
            var developer = new Developer
            {
                DeveloperId = 1,
                Name = "Name",
                City = "City",
                State = "State",
                Skype = "Skype",
                Whatsapp = "Whatsapp",
                Salary = 112.92M,
                Email = "email@email.com"
            };

            var exception = Assert.ThrowsException<ArgumentNullException>
                (() => _developerService.Update(new DeveloperDto { 
                    Developer = developer, 
                    Availabilities = _availabilities, 
                    WorkingTimes = _workingTimes }));
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
            _developerService.Add(new DeveloperDto { 
                Developer = developer1, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

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
            _developerService.Add(new DeveloperDto { 
                Developer = developer2, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

            developer2.Email = developer1.Email;

            Assert.ThrowsException<DbUpdateException>
                (() => _developerService.Update(new DeveloperDto { 
                    Developer = developer2, 
                    Availabilities = _availabilities, 
                    WorkingTimes = _workingTimes,
                    KnowledgeDtos = _knowledgeDtos
                }));
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
            _developerService.Add(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });

            developer.Name = "Name2";
            developer.Email = "email2@email.com";
            _developerService.Update(new DeveloperDto { 
                Developer = developer, 
                Availabilities = _availabilities, 
                WorkingTimes = _workingTimes,
                KnowledgeDtos = _knowledgeDtos
            });
            var developerWithGet = _developerService.GetDeveloperDto(developer.DeveloperId);

            Assert.AreEqual(developerWithGet.Developer.Name, developer.Name);
            Assert.AreEqual(developerWithGet.Developer.Email, developer.Email);
        }
    }
}
