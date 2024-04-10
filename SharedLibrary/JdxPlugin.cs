using Microsoft.Xrm.Sdk;
using System;
using System.Collections.ObjectModel;
using System.Linq;




namespace SharedLibrary
{
    public abstract class JdxPlugin : IPlugin
    {
        private Collection<Tuple<int, string, string, Action<LocalPluginContext>>> RegisteredEvents { get; } = new Collection<Tuple<int, string, string, Action<LocalPluginContext>>> ();

        protected void RegisterEvent(int stage, string eventName, string entityName, Action<LocalPluginContext> action)
        {
            RegisteredEvents.Add(new Tuple<int, string, string, Action<LocalPluginContext>>(stage, eventName, entityName, action));
        }

        protected string ChildClassName => GetType().Name;
        public void Execute(IServiceProvider serviceProvider)
        {
            if(serviceProvider is null) throw new ArgumentNullException(nameof(serviceProvider));

            using (var localContext = new LocalPluginContext(serviceProvider))
            {
                localContext.Trace($"Entered {ChildClassName}.Execute()");

                try
                {
                    var entityAction = (from a in RegisteredEvents
                                        where(
                                            a.Item1 == localContext.PluginExecutionContext.Stage &&
                                            a.Item2 == localContext.PluginExecutionContext.MessageName &&
                                            (string.IsNullOrWhiteSpace(a.Item3) || a.Item3 == localContext.PluginExecutionContext.PrimaryEntityName)
                                        )
                                        select a.Item4).FirstOrDefault();
                    if (entityAction == null)
                    {
                        return;
                    }

                    localContext.Trace($"{ChildClassName} is firing for Entity:{localContext.PluginExecutionContext.PrimaryEntityName}");

                    entityAction.Invoke(localContext);
                }
                catch (TimeoutException timeProblem)
                {
                    localContext.Trace("The service operation timed out. " + timeProblem.Message);
                    
                }
                catch (Exception e)
                {
                    localContext.Trace($"Exception: {e}");
                    throw;
                }
                finally
                {
                    localContext.Trace($"Exiting {ChildClassName}.Execute()");
                }
            }
        }
    }

    
}
