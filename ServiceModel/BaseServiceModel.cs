using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceModel
{
    public class BaseServiceModel : IServiceModel
    {
        public int DeleteExercises(Exercise exercise)
        {
            ExerciseDB db = new ExerciseDB();
            return db.DeleteExercises(exercise);
        }

        public int DeleteUser(User user)
        {
            UserDB db = new UserDB();
            return db.DeleteUser(user);
        }

        public int DeleteWorkout(Workout workout)
        {
            WorkoutDB db = new WorkoutDB();
            return db.DeleteWorkout(workout);
        }

        public int InsertExercises(Exercise exercise)
        {
            ExerciseDB db = new ExerciseDB();
            return db.InsertExercises(exercise);
        }

        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            return db.InsertUser(user);
        }

        public int InsertWorkout(Workout workout)
        {
            WorkoutDB db = new WorkoutDB();
            return db.InsertWorkout(workout);
        }

        public ExerciseList SelectAllExercises()
        {
            ExerciseDB db = new ExerciseDB();
            return db.SelectAll();
        }

        public ExerciseInWorkOutList SelectAllExInWorkOut()
        {
            ExerciseInWorkOutDB db = new ExerciseInWorkOutDB();
            return db.SelectAll();
        }

        public User Login(User user)
        {
            UserDB db = new UserDB();
            User us = db.Login(user);
            return us;
        }

        public int NewUser(User user)
        {
            UserDB db = new UserDB();
            return db.InsertUser(user);
        }

        public UserList SelectAllUsers()
        {
            UserDB db = new UserDB();
            return db.SelectAll();
        }

        public WorkoutList SelectAllWorkouts()
        {
            WorkoutDB db = new WorkoutDB();
            return db.SelectAll();
        }

        public int UpdateExercises(Exercise exercise)
        {
            ExerciseDB db = new ExerciseDB();
            return db.UpdateExercises(exercise);
        }

        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            return db.UpdateUser(user);
        }

        public int UpdateWorkout(Workout workout)
        {
            WorkoutDB db = new WorkoutDB();
            return db.UpdateWorkout(workout);
        }

        public bool IsEmailFree(string email)
        {
            UserDB db = new UserDB();
            if (db.SelectByEmail(email) == null)
            {
                return true;
            }
            return false;
        }

    }
}
