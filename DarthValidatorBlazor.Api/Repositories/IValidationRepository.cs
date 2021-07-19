using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarthValidatorBlazor.Models.Models;

namespace DarthValidatorBlazor.Api.Repositories
{
    interface IValidationRepository
    {
        public Validations AddValidation();
    }
}
