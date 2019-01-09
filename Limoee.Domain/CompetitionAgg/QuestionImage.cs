using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.CompetitionAgg
{
    public class QuestionImage : BaseValueObject
    {
        public QuestionImage() { }
        public QuestionImage(string name, string path)
        {
            Name = name;
            Path = path;
        }

        /// <summary>
        /// نام تصویر
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// مسیر فیزیکی فایل در سیسیتم
        /// </summary>
        public string Path { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
