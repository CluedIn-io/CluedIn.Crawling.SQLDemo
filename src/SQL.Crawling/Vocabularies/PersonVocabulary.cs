using System;
using System.Collections.Generic;
using System.Text;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.SQL.Vocabularies
{
    public class PersonVocabulary : SimpleVocabulary
    {
        public PersonVocabulary()
        {
            this.VocabularyName = "SQL Person";
            this.KeyPrefix = "sql.person";
            this.KeySeparator = ".";
            this.Grouping = EntityType.Infrastructure.User;

            this.AddGroup("SQL Person Details", group =>
            {
                FirstName = group.Add(new VocabularyKey("First Name", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                LastName = group.Add(new VocabularyKey("Last Name", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible));
                JobTitle = group.Add(new VocabularyKey("Job Title", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Email = group.Add(new VocabularyKey("Email", VocabularyKeyDataType.Email, VocabularyKeyVisibility.Visible));
                Age = group.Add(new VocabularyKey("Age", VocabularyKeyDataType.Number, VocabularyKeyVisibility.Visible));
                Gender = group.Add(new VocabularyKey("Gender", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                CreatedAt = group.Add(new VocabularyKey("Created at", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible));
            });
            AddMapping(FirstName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.FirstName);
            AddMapping(LastName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.LastName);
            AddMapping(JobTitle, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.JobTitle);
            AddMapping(Email, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Email);
            AddMapping(Gender, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Gender);


        }
        public VocabularyKey FirstName { get; set; }
        public VocabularyKey LastName { get; set; }
        public VocabularyKey Id { get; set; }
        public VocabularyKey JobTitle { get; set; }
        public VocabularyKey Email { get; set; }
        public VocabularyKey Age { get; set; }
        public VocabularyKey Gender { get; set; }
        public VocabularyKey CreatedAt { get; set; }

    }
}
