using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Limoee.Domain.CompetitionAgg;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Repository.Test
{
    [TestClass]
    public class CompetitionCrud
    {
        private Competition _competition;
        private readonly Guid _competitionId = new Guid();
        readonly LimoeeDataContext _dbContext = new LimoeeDataContext();

        [TestInitialize]
        public void CreateFakeCompetition()
        {
            //_compId = new Guid();
            var Ids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            //var answerIds = new[] {Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid()};

            //var questionId = Guid.NewGuid();

            _competition = new Competition()
            {
                Description = "Description Description Description",
                Id = _competitionId,
                EndDate = DateTime.Now.AddDays(7),
                StartDate = DateTime.Now,
                Title = "Competition number " + DateTime.Now.Ticks.ToString(),
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        Category = "SPORT",
                        Title = "SPORT Question",
                        Id = Ids[0],
                        Answers = new List<Answer>(){ 
                            new Answer()
                        {
                            Id = new Guid(),
                            Order = 1,
                            Title = "Answer 1 to SPORT Question"
                        } ,
                        new Answer()
                        {
                            Id = new Guid(),
                            Order = 2,
                            Title = "Answer 2 to SPORT Question"
                        }}

                    },
                    new Question()
                    {
                        Category = "CINEMA",
                        Title = "CINEMA Question",
                        Id = Ids[1],
                        Answers = new List<Answer>(){ 
                            new Answer()
                        {
                            Id = new Guid(),
                            Order = 1,
                            Title = "Answer 1 to CINEMA Question"
                        } ,
                        new Answer()
                        {
                            Id = new Guid(),
                            Order = 2,
                            Title = "Answer 2 to CINEMA Question"
                        }}
                    }
                },
            };
        }

        [TestMethod]
        public void Can_Save_Competition()
        {
            _dbContext.Competitions.Add(_competition);

            _dbContext.Commit();

            var savedCompetition = _dbContext.Competitions.FirstOrDefault(x => x.Id == _competition.Id);

            Assert.IsNotNull(savedCompetition);
        }

        [TestCleanup]
        public void Clean_FakeData()
        {
            //var savedCompetition = _dbContext.Competitions.FirstOrDefault(x => x.Id == _competition.Id);

            //_dbContext.Competitions.Remove(savedCompetition);

            //_dbContext.Commit();

        }

    }
}
