﻿using DAL.Models;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DTS.API.Services
{
    public sealed class ChangeUserPersonalDataCommand : ICommand
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }

        public ChangeUserPersonalDataCommand(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }

    public sealed class ChangeUserPersonalDataCommandHandler 
        : ICommandHandlerAsync<ChangeUserPersonalDataCommand>
    {
        private readonly IRepositoryWrapper repository;

        public ChangeUserPersonalDataCommandHandler(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(ChangeUserPersonalDataCommand command)
        {
            User user = await repository.Users.FindUserByIDAsync(command.Id);

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                user.Name = command.Name;
            }
            if (!string.IsNullOrWhiteSpace(command.Surname))
            {
                user.Surname = command.Surname;
            }
            if (!string.IsNullOrWhiteSpace(command.Email))
            {
                user.Email = command.Email;
            }

            await repository.Users.UpdateAsync(user);
        }
    }
}
