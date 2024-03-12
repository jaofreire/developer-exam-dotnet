using PixApi.Models;
using PixApi.Repositories;
using Tests.Helper;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void CreateClient()
        {
            //Arrange
            int KeyId = 1;
            string Type = "E-MAIL";
            string key = "joao.gabrie18872@gmail.com";
            
            var KeyPix = new KeyModel()
            {
                Id = KeyId,
                TypeKey = Type,
                Key = key
            };

            int clientId = 1;
            string name = "João Gabriel de Melo Freire";



            var client = new ClientModel()
            {
                Id = clientId,
                Name = name,
                //Key = KeyPix
            };

            await using var context = new MockDb().CreateDbContext();

            //Act
            //var response =  await KeyRepository.AddKey(context, KeyPix);
            //var responseClient = await ClientRepository.AddClient(context, client);

            ////Assert
            //Assert.IsType<KeyModel>(response);
            //Assert.True(context.Keys.Any());
            //Assert.True(context.Clients.Any());
            

        }
    }
}