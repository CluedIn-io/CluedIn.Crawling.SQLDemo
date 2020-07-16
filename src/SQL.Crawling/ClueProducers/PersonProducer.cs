using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;
using CluedIn.Crawling.SQL.Core.Models;
using CluedIn.Crawling.SQL.Vocabularies;

namespace CluedIn.Crawling.SQL.ClueProducers
{
    public class PersonProducer : BaseClueProducer<Person>
    {
        private readonly IClueFactory _factory;

        public PersonProducer([NotNull] IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }
        protected override Clue MakeClueImpl([NotNull] Person input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create(EntityType.Infrastructure.User, input.Id.ToString(), accountId);

            var data = clue.Data.EntityData;

            if (!string.IsNullOrWhiteSpace(input.FirstName) && !string.IsNullOrWhiteSpace(input.LastName))
            {
                data.Name = input.FirstName + ' ' + input.LastName;
            }

            if (!string.IsNullOrEmpty(input.CreatedAt))
            {
                if (DateTimeOffset.TryParse(input.CreatedAt, out var createdDate))
                {
                    data.CreatedDate = createdDate;
                }
            }

            var vocab = new PersonVocabulary();

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.FirstName] = input.FirstName.PrintIfAvailable();
            data.Properties[vocab.LastName] = input.LastName.PrintIfAvailable();
            data.Properties[vocab.JobTitle] = input.JobTitle.PrintIfAvailable();
            data.Properties[vocab.Age] = input.Age.PrintIfAvailable();
            data.Properties[vocab.Email] = input.Email.PrintIfAvailable();
            data.Properties[vocab.Gender] = input.Gender.PrintIfAvailable();
            data.Properties[vocab.CreatedAt] = input.CreatedAt.PrintIfAvailable();

            return clue;

        }
    }
}
