using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelpers.Utils;
using Xunit;

namespace CreateATests
{
    public class Date
    {
        [Fact]
        public void GivenTwoDaysBeforeADate_ThenADateTwoDaysBeforeSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Days.Before("2015-01-01".AsDate());

            result.Should().Be("2014-12-30".AsDate());
        }

        [Fact]
        public void GivenTwoDaysAfterADate_ThenADateTwoDaysAfterSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Days.After("2015-01-01".AsDate());

            result.Should().Be("2015-01-03".AsDate());
        }

        [Fact]
        public void GivenTwoWeeksBeforeADate_ThenADateTwoWeeksBeforeSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Weeks.Before("2015-01-01".AsDate());

            result.Should().Be("2014-12-18".AsDate());
        }

        [Fact]
        public void GivenTwoWeeksAfterADate_ThenADateTwoWeeksAfterSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Weeks.After("2015-01-01".AsDate());

            result.Should().Be("2015-01-15".AsDate());
        }

        [Fact]
        public void GivenTwoDaysBeforeAStringDate_ThenADateTwoDaysBeforeSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Days.Before("2015-01-01");

            result.Should().Be("2014-12-30".AsDate());
        }

        [Fact]
        public void GivenTwoDaysAfterAStringDate_ThenADateTwoDaysAfterSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Days.After("2015-01-01");

            result.Should().Be("2015-01-03".AsDate());
        }

        [Fact]
        public void GivenTwoYearsBeforeADate_ThenADateTwoYearsBeforeSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Years.Before("2015-01-01".AsDate());

            result.Should().Be("2013-01-01".AsDate());
        }

        [Fact]
        public void GivenTwoYearsAfterADate_ThenADateTwoYearsAfterSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Years.After("2015-01-01".AsDate());

            result.Should().Be("2017-01-01".AsDate());
        }

        [Fact]
        public void GivenTwoMonthsBeforeADate_ThenADateTwoMonthsBeforeSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Months.Before("2015-01-01".AsDate());

            result.Should().Be("2014-11-01".AsDate());
        }

        [Fact]
        public void GivenTwoMonthsAfterADate_ThenADateTwoMonthsAfterSuppliedDateIsReturned()
        {
            var result = Create.A.Date(2).Months.After("2015-01-01".AsDate());

            result.Should().Be("2015-03-01".AsDate());
        }
    }
}