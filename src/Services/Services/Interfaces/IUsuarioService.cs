using System;
using System.Collections.Generic;
using System.Text;
using Models.Dto;
using Models.Forms;

namespace Services.Interfaces
{
    public interface IUsuarioService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<UsuarioDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        UsuarioDto Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        UsuarioForm Create(UsuarioForm form);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        void Update(UsuarioForm form);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);
    }
}
