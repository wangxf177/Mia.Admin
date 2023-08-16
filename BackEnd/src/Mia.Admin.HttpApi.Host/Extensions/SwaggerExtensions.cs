using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mia.Admin.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// 为基于XML注释文件的操作、参数和模式注入人性化的描述
        /// 配置项目文件PropertyGroup-->GenerateDocumentationFile为True
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly">需要把注释内容包含到swagger里面的程序集</param>
        /// <exception cref="Exception"></exception>
        public static void ConfigSwaggerDefaultDocumentation(this IServiceCollection services, Assembly assembly)
        {
            services.ConfigureSwaggerGen(options =>
            {
                var assemblyName = assembly.GetName().Name;
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                if (File.Exists(filePath))
                {
                    options.IncludeXmlComments(filePath, true);
                }
                else
                {
                    var message = new StringBuilder($"请配置{assemblyName}项目文件：");
                    message.AppendLine("<PropertyGroup>");
                    message.AppendLine("  <GenerateDocumentationFile>True</GenerateDocumentationFile>");
                    message.AppendLine("</PropertyGroup>");
                    throw new Exception(message.ToString());
                }
            });
        }
    }
}
