using Moq;
using TestedApplication._Internal;
using TestedApplication.HardToTest;
using Xunit;

namespace TestedApplication.Tests.Mocking
{
    public class CountryDefenseControllerTests
    {
        private readonly Mock<IMissileLauncher> mock;
        private const string AuthenticationCode = "Password";

        public CountryDefenseControllerTests()
        {
            mock = new Mock<IMissileLauncher>();
        }
        [Fact]
        public void DestroyEnemy_With_Correct_Code_Should_Launch_Missile()
        {
            //arrange
            mock.Setup(l => l.LaunchMissile()).Returns(true);
            var launcher = mock.Object;

            var defenseController = new CountryDefenseController(launcher, AuthenticationCode);
            //act

            defenseController.DestroyEnemy(AuthenticationCode);

            //assert

            mock.Verify(missileLauncher => missileLauncher.LaunchMissile(), Times.Once);
        }


        [Fact]
        public void DestroyEnemy_With_Incorrect_Code_Should_Throw_AuthorizationFailedException()
        {
            //arrange
            mock.Setup(l => l.LaunchMissile()).Returns(true);
            var launcher = mock.Object;

            var defenseController = new CountryDefenseController(launcher, AuthenticationCode);

            //act & assert
            Assert.Throws<AuthorizationFailedException>(() => defenseController.DestroyEnemy("BadCode"));

            mock.Verify(missileLauncher => missileLauncher.LaunchMissile(), Times.Never);
        }


        [Fact]
        public void DestroyEnemy_Should_Throw_MissileException_When_Launch_Fails()
        {
            //arrange
            mock.Setup(l => l.LaunchMissile()).Returns(false);
            var launcher = mock.Object;

            var defenseController = new CountryDefenseController(launcher, AuthenticationCode);

            //act & assert
            Assert.Throws<MissileException>(() => defenseController.DestroyEnemy(AuthenticationCode));

            mock.Verify(missileLauncher => missileLauncher.LaunchMissile(), Times.Once);
        }
    }
}
