using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class StudentValidation : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the tracing service
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // The InputParameters collection contains all the data passed in the message request.  
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];

                // Obtain the organization service reference which you will need for  
                // web service calls.  
                IOrganizationServiceFactory serviceFactory =
                    (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {
                    tracingService.Trace("stage 1");
                    string mobile = entity.GetAttributeValue<string>("cr0f6_mobilenum");
                    tracingService.Trace("stage 2");
                    //entity["cr0f6_MobileNum"] = "1234";
                    //service.Update(entity);
                    Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
                    tracingService.Trace("stage 3");
                    tracingService.Trace(mobile);
                    if (!validatePhoneNumberRegex.IsMatch(mobile))
                    {
                        tracingService.Trace("stage 4");
                        tracingService.Trace("Mobile Phone not matching");
                        throw new InvalidPluginExecutionException("Mobile Phone not matching");
                    }
                    tracingService.Trace("stage 5");
                    if (entity.Attributes.Contains("cr0f6_mobilenum") == true)
                    {
                        QueryExpression query = new QueryExpression("cr0f6_student");
                        query.Criteria.AddCondition("cr0f6_mobilenum", ConditionOperator.Equal, mobile);
                        query.Criteria.AddCondition("cr0f6_studentid", ConditionOperator.NotEqual, entity.Id);
                        query.ColumnSet = new ColumnSet(false);
                        tracingService.Trace("stage 5");
                        EntityCollection students = service.RetrieveMultiple(query);
                        tracingService.Trace("stage 6");
                        if (students.Entities.Count > 0)
                        {
                            tracingService.Trace("stage 7");
                            tracingService.Trace("Duplicate phone number");
                            throw new InvalidPluginExecutionException("Duplicate phone number");
                        }
                    }
                    
                }

                //catch (FaultException<OrganizationServiceFault> ex)
                //{
                //    throw new InvalidPluginExecutionException("An error occurred in FollowUpPlugin.", ex);
                //}

                catch (Exception ex)
                {
                    tracingService.Trace("Plugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
