namespace Financial.Control.Domain.Constants
{
    public class ApplicationMessage
    {
        public class UserMessage
        {
            public static string UserCreateError() => "Erro ao cadastrar o usuário.";
            public static string UserCreateSuccess() => "Usuário criado com sucesso.";

            public static string UserUpdateError() => "Erro ao atualizar o usuário";
            public static string UserUpdateSuccess() => "Usuário atualizado com sucesso.";

            public static string UserGetSuccess() => "Usuário encontrado.";
            public static string UserGetError() => "Erro ao buscar o usuário.";

            public static string UserUpdatePasswordSuccess() => "Senha do usuário atualizada com sucess.";
            public static string UserUpdatePasswordError() => "Erro ao atualizar a senha do usuário.";

            public static string UserNotFound() => "O usuário não foi encontrado";
            public static string UserOrPasswordInvalid() => "Usuário ou senha inválidos.";
            public static string PasswordNotEquals() => "A senha atual informada não corresponde.";
            public static string UserEmailAlreadyExists(string email) => $"O e-mail '{email}' informado já está cadastrado no sistema.";
        }
        public class CardMessage
        {
            public static string CardCreateError() => "Erro ao cadastrar o cartão.";
            public static string CardCreateSuccess() => "Cartão criado com sucesso.";
            public static string CardUpdateError() => "Erro ao atualizar os dados do cartão.";
            public static string CardUpdateSuccess() => "Cartão atualizado com sucesso.";
            public static string CardDeleteError() => "Erro ao remover o cartão o usuário.";
            public static string CardDeleteSuccess() => "Cartão removido com sucesso.";
            public static string CardGetError() => "Erro ao coletar os dados do cartão.";
            public static string CardGetSuccess() => "Dados do cartão coletados com sucesso.";
            public static string CardListError() => "Erro ao listar os cartões do usuário.";
            public static string CardListSuccess() => "Os cartões do usuário foram coletados com sucesso.";
            public static string CardListNotFound(string name) => $"O usuário '{name}' não possui cartões.";
            public static string CardNotFound() => "O cartão não foi encontrado.";
            public static string CardAlreadyExists(string cardNumber) => $"O cartão '{cardNumber}' já existe na base de dados.";
            public static string CardFlagNotSupported() => $"A bandeira do cartão inserido não é suportado pelo sistema.";
        }

        public class LoginMessage
        {
            public static string UserOrPasswordInvalid() => "Usuário ou senha inválidos.";
            public static string LoginSuccess() => "Login realizado com sucesso.";
            public static string LoginError() => "Erro ao realizar o login.";
        }

        public class RevenueMessage
        {
            public static string RevenueCreateError() => "Erro ao criar a receita/renda.";
            public static string RevenueUpdateError() => "Erro ao atualizar a receita/renda.";
            public static string RevenueUpdateSuccess() => "Receita/renda atualizada com sucesso.";
            public static string RevenueDeleteError() => "Erro ao remover Receita/renda.";
            public static string RevenueDeleteSuccess() => "Receita/renda foi removida com sucesso.";
            public static string RevenueGetError() => "Erro ao coletar dados da receita.";
            public static string RevenueGetNotFound() => "A receita não foi encontrada.";
            public static string RevenueCreateSuccess() => "Receita criada com sucesso.";
            public static string RevenueGetSuccess() => "A receita do usuário foi encontrada com sucesso.";
            public static string RevenueListError() => "Erro ao listas as receitas do usuário.";
            public static string RevenueListNotFound() => "Não foram encontradas receitas do usuário.";
            public static string RevenueListSuccess() => "As receitas do usuário foram coletadas com sucesso.";
        }

        public class CategoryMessage
        {
            public static string CategoryListError() => "Erro ao listar todas as categorias.";
            public static string CategoryListsuccess() => "Todas as categorias foram listadas com success.";
            public static string CategoryListNotFound() => "Não há categorias para listar.";
        }

        public class ServerMessage
        {
            public static string InternalServerError() => "Internal Server Error.";
        }

        public class ValidationMessage
        {
            public static string ValidationFailed() => "O formulário possui um ou mais erros. Verifique os campos informados.";
        }

        public class GenericMessage
        {
            public static string IdNotExists(long? id) => $"O ID {id} informado é inválido.";
            public static string EmailConflict() => $"Conflito ao cadastrar o e-mail.";

        }
    }
}
