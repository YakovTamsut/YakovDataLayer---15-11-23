using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceModel
    {
        [OperationContract] ExerciseList SelectAllExercises();
        [OperationContract] ExerciseInWorkOutList SelectAllExInWorkOut();
        [OperationContract] UserList SelectAllUsers();
        [OperationContract] WorkoutList SelectAllWorkouts();
        [OperationContract] int InsertExercises(Exercise exercise);
        [OperationContract] int UpdateExercises(Exercise exercise);
        [OperationContract] int DeleteExercises(Exercise exercise);
        [OperationContract] int InsertWorkout(Workout workout);
        [OperationContract] int UpdateWorkout(Workout workout);
        [OperationContract] int DeleteWorkout(Workout workout);
        [OperationContract] User Login(User user);
        [OperationContract] int NewUser(User user);
        [OperationContract] bool IsEmailFree(string email);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
    }
}
