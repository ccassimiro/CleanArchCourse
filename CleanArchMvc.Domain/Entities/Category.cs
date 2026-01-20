using System.Collections.Generic;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        private readonly List<Product> _products = new(); 
        public IReadOnlyCollection<Product> Products => _products;

        public Category(string name)
        {
            ValidateDomain(name);
        }

        // For first migration execution only
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            Name = name;
        }
    }
}
