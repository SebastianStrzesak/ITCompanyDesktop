using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Employees",
                    new BaseCommand(() => this.ShowAllEmployee())),
                new CommandViewModel(
                    "Employee",
                    new BaseCommand(() => this.CreateEmployee())),

                new CommandViewModel(
                    "Softwares",
                    new BaseCommand(() => this.ShowAllSoftware())),
                new CommandViewModel(
                    "Software",
                    new BaseCommand(() => this.CreateSoftware())),

                new CommandViewModel(
                    "Equipments",
                    new BaseCommand(() => this.ShowAllEquipment())),
                new CommandViewModel(
                    "Equipment",
                    new BaseCommand(() => this.CreateEquipment())),

                new CommandViewModel(
                    "Salaries",
                    new BaseCommand(() => this.ShowAllSalaries())),
                new CommandViewModel(
                    "Salarie",
                    new BaseCommand(() => this.CreateSalarie())),

                new CommandViewModel(
                    "Leaves",
                    new BaseCommand(() => this.ShowAllLeaves())),
                new CommandViewModel(
                    "Leave",
                    new BaseCommand(() => this.CreateLeave())),

                new CommandViewModel(
                    "PerformanceReviews",
                    new BaseCommand(() => this.ShowAllPerformancesReviews())),
                new CommandViewModel(
                    "PerformanceReview",
                    new BaseCommand(() => this.CreatePerformanceReview())),

                new CommandViewModel(
                    "Departments",
                    new BaseCommand(() => this.ShowAllDepartments())),
                new CommandViewModel(
                    "Department",
                    new BaseCommand(() => this.CreateDepartmen())),

                new CommandViewModel(
                    "Invoices",
                    new BaseCommand(() => this.ShowAllInvoice())),
                new CommandViewModel(
                    "Invoice",
                    new BaseCommand(() => this.CreateInvoice())),

                new CommandViewModel(
                    "Trainings",
                    new BaseCommand(() => this.ShowAllTrainings())),
                new CommandViewModel(
                    "Training",
                    new BaseCommand(() => this.CreateTraining())),

                new CommandViewModel(
                    "Clients",
                    new BaseCommand(() => this.ShowAllClients())),
                new CommandViewModel(
                    "Client",
                    new BaseCommand(() => this.CreateClient())),

                new CommandViewModel(
                    "ProjectBudgets",
                    new BaseCommand(() => this.ShowAllProjectBudgets())),
                new CommandViewModel(
                    "ProjectBudget",
                    new BaseCommand(() => this.CreateProjectBudget())),

                new CommandViewModel(
                    "Projects",
                    new BaseCommand(() => this.ShowAllProjects())),
                new CommandViewModel(
                    "Project",
                    new BaseCommand(() => this.CreateProject())),

                new CommandViewModel(
                    "TimeSheets",
                    new BaseCommand(() => this.ShowAllTimeSheets())),
                new CommandViewModel(
                    "TimeSheet",
                    new BaseCommand(() => this.CreateTimeSheets())),

                new CommandViewModel(
                    "Tasks",
                    new BaseCommand(() => this.ShowAllTasks())),
                new CommandViewModel(
                    "Task",
                    new BaseCommand(() => this.CreateTask())),

                new CommandViewModel(
                    "TaskAssignments",
                    new BaseCommand(() => this.ShowAllTaskAssignment())),
                new CommandViewModel(
                    "TaskAssignment",
                    new BaseCommand(() => this.CreateTaskAssignment()))
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateEmployee()
        {
            NewEmployeeViewModel workspace = new NewEmployeeViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateSoftware()
        {
            NewSoftwareViewModel workspace = new NewSoftwareViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateEquipment()
        {
            NewEquipmentViewModel workspace = new NewEquipmentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateSalarie()
        {
            NewSalarieViewModel workspace = new NewSalarieViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateLeave()
        {
            NewLeaveViewModel workspace = new NewLeaveViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePerformanceReview()
        {
            NewPerformanceReviewViewModel workspace = new NewPerformanceReviewViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateDepartmen()
        {
            NewDepartmentViewModel workspace = new NewDepartmentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateInvoice()
        {
            NewInvoiceViewModel workspace = new NewInvoiceViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateTraining()
        {
            NewTrainingViewModel workspace = new NewTrainingViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateClient()
        {
            NewClientViewModel workspace = new NewClientViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateProjectBudget()
        {
            NewProjectBudgetViewModel workspace = new NewProjectBudgetViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateProject()
        {
            NewProjectViewModel workspace = new NewProjectViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateTimeSheets()
        {
            NewTimesheetViewModel workspace = new NewTimesheetViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateTask()
        {
            NewTaskViewModel workspace = new NewTaskViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void CreateTaskAssignment()
        {
            NewTaskAssignmentViewModel workspace = new NewTaskAssignmentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEmployee()
        {
            AllEmployeesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEmployeesViewModel)
                as AllEmployeesViewModel;
            if (workspace == null)
            {
                workspace = new AllEmployeesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllSoftware()
        {
            AllSoftwaresViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllSoftwaresViewModel)
                as AllSoftwaresViewModel;
            if (workspace == null)
            {
                workspace = new AllSoftwaresViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllEquipment()
        {
            AllEquipmentViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllEquipmentViewModel)
                as AllEquipmentViewModel;
            if (workspace == null)
            {
                workspace = new AllEquipmentViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllSalaries()
        {
            AllSalariesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllSalariesViewModel)
                as AllSalariesViewModel;
            if (workspace == null)
            {
                workspace = new AllSalariesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllLeaves()
        {
            AllLeavesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllLeavesViewModel)
                as AllLeavesViewModel;
            if (workspace == null)
            {
                workspace = new AllLeavesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllPerformancesReviews()
        {
            AllPerformanceReviewsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllPerformanceReviewsViewModel)
                as AllPerformanceReviewsViewModel;
            if (workspace == null)
            {
                workspace = new AllPerformanceReviewsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllDepartments()
        {
            AllDepartmentsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllDepartmentsViewModel)
                as AllDepartmentsViewModel;
            if (workspace == null)
            {
                workspace = new AllDepartmentsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllTrainings()
        {
            AllTrainingsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllTrainingsViewModel)
                as AllTrainingsViewModel;
            if (workspace == null)
            {
                workspace = new AllTrainingsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllInvoice()
        {
            AllInvoicesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllInvoicesViewModel)
                as AllInvoicesViewModel;
            if (workspace == null)
            {
                workspace = new AllInvoicesViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllClients()
        {
            AllClientsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllClientsViewModel)
                as AllClientsViewModel;
            if (workspace == null)
            {
                workspace = new AllClientsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllProjectBudgets()
        {
            AllProjectBudgetsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllProjectBudgetsViewModel)
                as AllProjectBudgetsViewModel;
            if (workspace == null)
            {
                workspace = new AllProjectBudgetsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllProjects()
        {
            AllProjectsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllProjectsViewModel)
                as AllProjectsViewModel;
            if (workspace == null)
            {
                workspace = new AllProjectsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllTimeSheets()
        {
            AllTimeSheetsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllTimeSheetsViewModel)
                as AllTimeSheetsViewModel;
            if (workspace == null)
            {
                workspace = new AllTimeSheetsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllTasks()
        {
            AllTasksViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllTasksViewModel)
                as AllTasksViewModel;
            if (workspace == null)
            {
                workspace = new AllTasksViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllTaskAssignment()
        {
            AllTaskAssignmentsViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllTaskAssignmentsViewModel)
                as AllTaskAssignmentsViewModel;
            if (workspace == null)
            {
                workspace = new AllTaskAssignmentsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
