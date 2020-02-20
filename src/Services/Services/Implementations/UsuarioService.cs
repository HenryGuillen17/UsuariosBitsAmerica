using AutoMapper;
using Models.Dao;
using Models.Dto;
using Models.Forms;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using UnitOfWork.Interfaces;

namespace Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<UsuarioDto> GetAll()
        {
            var list = _unitOfWork.Create().Repositories.UsuarioRepository.GetAll();
            return Mapper.Map<List<UsuarioDto>>(list);
        }

        public UsuarioDto Get(int id)
        {
            return Mapper.Map<UsuarioDto>(_unitOfWork.Create().Repositories.UsuarioRepository.Get(id));
        }

        public UsuarioForm Create(UsuarioForm form)
        {
            var objeto = Mapper.Map<Usuario>(form);
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.UsuarioRepository.Create(objeto);
                context.SaveChanges();
                return Mapper.Map<UsuarioForm>(objeto);
            }
        }

        public void Update(UsuarioForm form)
        {
            var objeto = Mapper.Map<Usuario>(form);
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.UsuarioRepository.Update(objeto);
                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            _unitOfWork.Create().Repositories.UsuarioRepository.Remove(id);
        }
    }
}
