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
        public void GivenTwoDaysBeforeADate_ReturnsADateTwoDaysBeforeSuppliedDate()
        {
            var result = Create.A.Date(2).Days.Before("2015-01-01".AsDate());

            result.Should().Be("2014-12-30".AsDate());
        }

        [Fact]
        public void GivenTwoDaysAfterADate_ReturnsADateTwoDaysAfterSuppliedDate()
        {
            var result = Create.A.Date(2).Days.After("2015-01-01".AsDate());

            result.Should().Be("2015-01-03".AsDate());
        }

        [Fact]
        public void GivenTwoWeeksBeforeADate_ReturnsADateTwoWeeksBeforeSuppliedDate()
        {
            var result = Create.A.Date(2).Weeks.Before("2015-01-01".AsDate());

            result.Should().Be("2014-12-18".AsDate());
        }

        [Fact]
        public void GivenTwoWeeksAfterADate_ReturnsADateTwoWeeksAfterSuppliedDate()
        {
            var result = Create.A.Date(2).Weeks.After("2015-01-01".AsDate());

            result.Should().Be("2015-01-15".AsDate());
        }

        [Fact]
        public void GivenTwoDaysBeforeAStringDate_ReturnsADateTwoDaysBeforeSuppliedDate()
        {
            var result = Create.A.Date(2).Days.Before("2015-01-01");

            result.Should().Be("2014-12-30".AsDate());
        }

        [Fact]
        public void GivenTwoDaysAfterAStringDate_ReturnsADateTwoDaysAfterSuppliedDate()
        {
            var result = Create.A.Date(2).Days.After("2015-01-01");

            result.Should().Be("2015-01-03".AsDate());
        }

        [Fact]
        public void GivenTwoYearsBeforeADate_ReturnsADateTwoYearsBeforeSuppliedDate()
        {
            var result = Create.A.Date(2).Years.Before("2015-01-01".AsDate());

            result.Should().Be("2013-01-01".AsDate());
        }

        [Fact]
        public void GivenTwoYearsAfterADate_ReturnsADateTwoYearsAfterSuppliedDate()
        {
            var result = Create.A.Date(2).Years.After("2015-01-01".AsDate());

            result.Should().Be("2017-01-01".AsDate());
        }

        [Fact]
        public void GivenTwoMonthsBeforeADate_ReturnsADateTwoYearsMonthsSuppliedDate()
        {
            var result = Create.A.Date(2).Months.Before("2015-01-01".AsDate());

            result.Should().Be("2014-11-01".AsDate());
        }

        [Fact]
        public void GivenTwoMonthsAfterADate_ReturnsADateTwoMonthsAfterSuppliedDate()
        {
            var result = Create.A.Date(2).Months.After("2015-01-01".AsDate());

            result.Should().Be("2015-03-01".AsDate());
        }
    }
}
