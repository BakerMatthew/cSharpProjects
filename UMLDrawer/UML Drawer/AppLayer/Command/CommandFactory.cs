using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class CommandFactory
    {
        private static CommandFactory instance;
        private static readonly object MyLock = new object();
        private CommandFactory() { }

        public static CommandFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (instance == null)
                        instance = new CommandFactory();
                }
                return instance;
            }
        }

        public Drawing TargetDrawing { get; set; }
        public Invoker Invoker { get; set; }

        /// <param name="commandType">
        /// New, AddAssociation, AddUmlClass, Remove, Select, Deselect, Load, Save
        /// </param>
        /// <param name="commandParameters">An array of optional parametesr whose sementics depedent on the command type
        ///     For new, no additional parameters needed
        ///     For add, 
        ///         [0]: Type       reference type for assembly containing the association type resource
        ///         [1]: string     association type -- a fully qualified resource name
        ///         [2]: Point      center location for the association, defaut = top left corner
        ///         [3]: float      scale factor</param>
        ///     For remove, no additional parameters needed
        ///     For select,
        ///         [0]: Point      Location at which a association could be selected
        ///     For deselect, no additional parameters needed
        ///     For load,
        ///         [0]: string     filename of file to load from  
        ///     For save,
        ///         [0]: string     filename of file to save to 
        /// </param>
        public virtual void CreateAndExecute(string commandType, params object[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(commandType)) return;

            if (TargetDrawing == null) return;

            Command command = null;
            switch (commandType.Trim().ToUpper())
            {
                case "NEW":
                    command = new NewCommand();
                    break;
                case "ADDASSOCATION":
                    command = new AddAssociationCommand(commandParameters);
                    break;
                case "ADDUMLCLASS":
                    command = new AddUmlClassCommand(commandParameters);
                    break;
                case "REMOVE":
                    command = new RemoveSelectedCommand();
                    break;
                case "SELECT":
                    command = new SelectCommand(commandParameters);
                    break;
                case "DESELECT":
                    command = new DeselectAllCommand();
                    break;
                case "LOAD":
                    command = new LoadCommand(commandParameters);
                    break;
                case "SAVE":
                    command = new SaveCommand(commandParameters);
                    break;
            }

            if (command != null)
            {
                command.TargetDrawing = TargetDrawing;
                Invoker.EnqueueCommandForExecution(command);
            }
        }
    }
}

