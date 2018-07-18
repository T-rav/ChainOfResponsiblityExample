using FluentAssertions;
using NUnit.Framework;

namespace Implementation.Tests
{
    [TestFixture]
    public class ChainTests
    {
        [Test]
        public void When_Team_Lead_Purchasing_Under_Two_Hundred_Rand_Expect_Self_Approval()
        {
            // arrange
            var purchase = new Purchase { Amount = 190.99, Description = "Stationary" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeTrue();
            actual.By.Should().Be(brendon);
            actual.Notes.Should().Be("Your purchase of Stationary has been approved");
        }

        [Test]
        public void When_Team_Lead_Purchasing_At_Two_Hundred_Rand_Expect_Self_Approval()
        {
            // arrange
            var purchase = new Purchase { Amount = 200.00, Description = "Stationary" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeTrue();
            actual.By.Should().Be(brendon);
            actual.Notes.Should().Be("Your purchase of Stationary has been approved");
        }

        [Test]
        public void When_Team_Lead_Purchasing_Under_One_Thousand_Rand_Expect_Manager_To_Approve()
        {
            // arrange
            var purchase = new Purchase { Amount = 998.99, Description = "Team Lunch" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeTrue();
            actual.By.Should().Be(trav);
            actual.Notes.Should().Be("Your purchase of Team Lunch has been approved");
        }

        [Test]
        public void When_Team_Lead_Purchasing_At_One_Thousand_Rand_Expect_Manager_To_Approve()
        {
            // arrange
            var purchase = new Purchase { Amount = 1000.00, Description = "Team Lunch" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeTrue();
            actual.By.Should().Be(trav);
            actual.Notes.Should().Be("Your purchase of Team Lunch has been approved");
        }

        [Test]
        public void When_Team_Lead_Purchasing_Over_One_Thousand_Rand_Expect_Director_To_Approve()
        {
            // arrange
            var purchase = new Purchase { Amount = 1000.10, Description = "Graphics Card" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeTrue();
            actual.By.Should().Be(pete);
            actual.Notes.Should().Be("Your purchase of Graphics Card has been approved");
        }

        [Test]
        public void When_Team_Lead_Purchasing_At_Five_Thousand_Rand_Expect_Director_To_Deny()
        {
            // arrange
            var purchase = new Purchase { Amount = 5000.00, Description = "New Monitors" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeFalse();
            actual.By.Should().Be(pete);
            actual.Notes.Should().Be("I need to speak with the CEO first!");
        }

        [Test]
        public void When_Team_Lead_Purchasing_Over_Five_Thousand_Rand_Expect_Director_To_Deny()
        {
            // arrange
            var purchase = new Purchase { Amount = 5100.00, Description = "New Monitors" };

            var brendon = new TeamLead("Brendon");
            var trav = new Manager("Trav");
            var pete = new Director("Pete");

            brendon.SetSuccessor(trav);
            trav.SetSuccessor(pete);
            // act
            var actual = brendon.ProcessRequest(purchase);
            // assert
            actual.Approved.Should().BeFalse();
            actual.By.Should().Be(pete);
            actual.Notes.Should().Be("I need to speak with the CEO first!");
        }
    }
}
