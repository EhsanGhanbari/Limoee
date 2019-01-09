using System;
using System.Collections.Generic;
using System.Linq;
using Limoee.Application.BannerService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;
using Limoee.Application.Mappings;
using Limoee.Domain.CompetitionAgg;
using Limoee.Infrastructure.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Application.Test
{
    [TestClass]
    public class AutoMapperConfigurationTest
    {
        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public void ConfigIsOk()
        {
            AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public void Convert_CompetitionList_to_CompetitionDTOList()
        {
            var item = AutoMapper.Mapper.Map<PagedResult<Competition>, PagedResult<CompetitionDTO>>(new PagedResult<Competition>() { Results = new List<Competition>(){new Competition()} });

            Assert.IsTrue(item.Results.Any());
        }

        [TestMethod]
        public void Convert_Answer_to_AnswerDTO()
        {
            var item = AutoMapper.Mapper.Map<Answer, AnswerDTO>(new Answer(){Title = "TEST"});

            Assert.IsTrue(item.Title == "TEST");
        }

        [TestMethod]
        public void Convert_Question_to_QuestionDTO()
        {
            var item = AutoMapper.Mapper.Map<Question, QuestionDTO>(new Question() { Category = "TEST" });

            Assert.IsTrue(item.Category == "TEST");
        }

        [TestMethod]
        public void Convert_Competition_to_CompetitionDTO()
        {
            var item = AutoMapper.Mapper.Map<Competition, CompetitionDTO>(new Competition() { Title = "TEST" });

            Assert.IsTrue(item.Title == "TEST");
        }

        [TestMethod]
        public void Convert_CreateCompetitionCommand_To_Competition()
        {
            var Competition = AutoMapper.Mapper.Map<CreateCompetitionCommand, Competition>(new CreateCompetitionCommand()
            {
                Title = "TestCompetition",
                Questions = new List<QuestionDTO>() { new QuestionDTO() { Category = "SPORT"} }

            });

            Assert.IsTrue(Competition.Title == "TestCompetition");
            Assert.IsTrue(Competition.Questions.Any());
            Assert.IsTrue(Competition.Questions[0].Category=="SPORT");
        }
    }


}
