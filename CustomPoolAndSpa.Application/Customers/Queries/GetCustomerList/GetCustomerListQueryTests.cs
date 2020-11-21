﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomPoolAndSpa.Domain;

namespace CustomPoolAndSpa.Application.Customers.Queries.GetCustomerList
{
    class GetCustomerListQueryTests
    {
        [TestFixture]
        public class GetCustomersListQueryTests
        {
            private GetCustomersListQuery _query;
            private AutoMoqer _mocker;
            private Customer _customer;

            private const int Id = 1;
            private const string Name = "Customer 1";

            [SetUp]
            public void SetUp()
            {
                _mocker = new AutoMoqer();

                _customer = new Customer()
                {
                    Id = Id,
                    Name = Name
                };

                _mocker.GetMock<IDbSet<Customer>>()
                    .SetUpDbSet(new List<Customer> { _customer });

                _mocker.GetMock<IDatabaseService>()
                    .Setup(p => p.Customers)
                    .Returns(_mocker.GetMock<IDbSet<Customer>>().Object);

                _query = _mocker.Create<GetCustomersListQuery>();
            }

            [Test]
            public void TestExecuteShouldReturnListOfCustomers()
            {
                var results = _query.Execute();

                var result = results.Single();

                Assert.That(result.Id, Is.EqualTo(Id));
                Assert.That(result.Name, Is.EqualTo(Name));
            }
        }
    }
}
