using TestedApplication._Internal;

namespace TestedApplication.HardToTest
{
    public class CountryDefenseController
    {
        private readonly IMissileLauncher _launcher;
        private string _authenticationCode;

        public CountryDefenseController(IMissileLauncher launcher, string authenticationCode)
        {
            _launcher = launcher;
            _authenticationCode = authenticationCode;
        }

        public void DestroyEnemy(string secretCode)
        {
            if (!IsAuthorized(secretCode))
            {
                throw new AuthorizationFailedException();
            }

            var succeed=_launcher.LaunchMissile();

            if (!succeed)
            {
                throw new MissileException();
            }
        }

        private bool IsAuthorized(string providedCode)
        {
            return providedCode==_authenticationCode;
        }
    }
}