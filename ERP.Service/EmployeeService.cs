using ERP.BusinessObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service
{
    public class EmployeeService
    {
        /// <summary>
        /// Listado de Empleados
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<EmployeeBO>> Listado()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://crudcrud.com/api/b142d3bc244344d4a84fc9380af1b97b/qbo"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    IEnumerable<EmployeeBO> employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeBO>>(apiResponse);
                    return employees;
                }
            }
        }
        /// <summary>
        /// Insertar Empleados
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<EmployeeBO> Insertar(EmployeeBO employee)
        {
            var data = new
            {

                nombre = employee.nombre,
                salario = employee.salario,
                edad = employee.edad,
                perfil = employee.perfil
            };

            var content = new StringContent(JsonConvert.SerializeObject(data).ToString(), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("https://crudcrud.com/api/b142d3bc244344d4a84fc9380af1b97b/qbo", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EmployeeBO employeeBO = JsonConvert.DeserializeObject<EmployeeBO>(apiResponse);
                    return employeeBO;

                }

            }
        }

        /// <summary>
        /// Actualizar Empleados
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<EmployeeBO> Actualizar(EmployeeBO employee)
        {
            var data = new
            {

                nombre = employee.nombre,
                salario = employee.salario,
                edad = employee.edad,
                perfil = employee.perfil
            };

            var content = new StringContent(JsonConvert.SerializeObject(data).ToString(), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync("https://crudcrud.com/api/b142d3bc244344d4a84fc9380af1b97b/qbo/"+ employee._id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EmployeeBO employeeBO = JsonConvert.DeserializeObject<EmployeeBO>(apiResponse);
                    return employeeBO;

                }
            }
        }

        /// <summary>
        /// Eliminar Empleados
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static async Task<bool> Eliminar(string ID)
        {
            bool exito = true;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("https://crudcrud.com/api/b142d3bc244344d4a84fc9380af1b97b/qbo/" + ID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

            }
            catch 
            {
                exito = false;
            }
        
            return exito;

        }



    }
}
