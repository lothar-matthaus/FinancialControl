namespace Financial.Control.Domain.Constants
{
    public class Message
    {
        public class UserMessage
        {
            public static string UserCreateError() => "Erro ao cadastrar o usuário.";
            public static string UserCreateSuccess() => "Usuário criado com sucesso.";
            public static string UserUpdateError() => "Erro ao atualizar o usuário";
            public static string UserNotFound() => "O usuário não foi encontrado";
            public static string UserOrPasswordInvalid() => "Usuário ou senha inválidos.";
            public static string UserEmailAlreadyExists(string email) => $"O e-mail '{email}' informado já está cadastrado no sistema.";
            public static string UserUpdateSuccess() => "Usuário atualizado com sucesso.";
            public static string UserGetSuccess() => "Usuário encontrado.";
            public static string UserGetError() => "Erro ao buscar o usuário.";
        }
        public class CardMessage
        {
            public static string CardCreateError() => "Erro ao cadastrar o cartão.";
            public static string CardCreateSuccess() => "Cartão criado com sucesso.";
            public static string CardUpdateError() => "Erro ao atualizar os dados do cartão.";
            public static string CardUpdateSuccess() => "Cartão atualizado com sucesso.";
            public static string CardNotFound() => $"O cartão não foi encontrado. ";
            public static string CardAlreadyExists(string cardNumber) => $"O cartão '{cardNumber}' já existe na base de dados.";
        }

        public class LoginMessage
        {
            public static string UserOrPasswordInvalid() => "Usuário ou senha inválidos.";
            public static string LoginSuccess() => "Login realizado com sucesso.";
            public static string LoginError() => "Erro ao realizar o login.";
        }
    }
}
