using KarataClub.Domain.Identity.AppUsers;
using KarataClub.Tests.Common.Identity;

namespace KarataClub.Domain.Tests.IdentityTests
{
    public class AppUserTests
    {
        [Fact]
        public void CreateUser_ShouldPass_ForValidData()
        {

            string firstName = "nada";
            string lastName="mohamed";
            string email = "nada@gmail.com";
            string phone = "01114308227";
            string userName = "nada@gmail.com";
            var userRes = AppUserFactory.Create(firstName,lastName,email,phone,userName);
            Assert.True(userRes.IsSuccess);
            AppUser user = userRes.Value;
            Assert.NotNull(user);
            Assert.Equal(user.FirstName,firstName);
            Assert.Equal(user.LastName,lastName);
            Assert.Equal(user.Email,email);
            Assert.Equal(user.PhoneNumber,phone);
            Assert.Equal(user.UserName,userName);

        }
         [Theory]
        [InlineData("", "mohamed", "nada@gmail.com", "01114308227", "nada@gmail.com")]
        [InlineData("nada", "", "nada@gmail.com", "01114308227", "nada@gmail.com")]
        [InlineData("nada", "mohamed", "", "01114308227", "nada@gmail.com")]
        [InlineData("nada", "mohamed", "nada@gmail.com", "", "nada@gmail.com")]
        [InlineData("nada", "mohamed", "nada@gmail.com", "01114308227", "")]
        public void CreateUser_ShouldFail_ForInvalidValidData(
             string fName,string lName,string email,string phone,string userName)
        {
            var userRes = AppUserFactory.Create(fName, lName, email, phone, userName);
            Assert.True(userRes.IsFailure);

        }
    }
}
