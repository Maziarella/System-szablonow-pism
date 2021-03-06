﻿using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS.API.Services
{
    public class ActivateTemplateCommand : ICommand
    {
        public int Id { get; }

        public ActivateTemplateCommand(int id)
        {
            Id = id;
        }
    }

    public sealed class ActivateTemplateCommandHandler 
        : ICommandHandlerAsync<ActivateTemplateCommand>
    {

        private readonly IRepositoryWrapper repository;
        private readonly string _activeTemplateState = "Active";

        public ActivateTemplateCommandHandler(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(ActivateTemplateCommand command)
        {
            var template = await repository.Templates.FindTemplateByIdAsync(command.Id);
            var activeState = await repository.TemplateState.FindTemplateStateByName(_activeTemplateState);

            var isActiveTemplateVersion = !(template.TemplateVersion.Where(tv => tv.State.Equals(activeState)).ToList().Count == 0);

            if (isActiveTemplateVersion)
            {
                template.State = activeState;
                await repository.Templates.UpdateTemplateAsync(template);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
