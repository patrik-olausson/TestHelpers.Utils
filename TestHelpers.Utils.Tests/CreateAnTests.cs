using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelpers.Utils;
using Xunit;

namespace CreateAnTests
{
    public class EmptySetOf
    {
        [Fact]
        public void GivenTypeIsString_ThenAnEmptyStringCollectionIsReturned()
        {
            var set = Create.An.EmptySetOf<string>();

            set.Should().HaveCount(0);
        }
    }
}