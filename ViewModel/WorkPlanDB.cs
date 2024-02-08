using Model;
using PlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorkoutPlanDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new WorkoutPlan() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            WorkoutPlan userWorkPlan = entity as WorkoutPlan;
            userWorkPlan.ID = int.Parse(reader["id"].ToString());
            userWorkPlan.Day =int.Parse(reader["day"].ToString());

            int userId = int.Parse(reader["userID"].ToString());
            UserDB userDB = new UserDB();
            userWorkPlan.User = userDB.SelectById(userId);

            int workoutID = int.Parse(reader["WorkoutID"].ToString());
            WorkoutDB workoutDB = new WorkoutDB();
            userWorkPlan.Workout = workoutDB.SelectById(workoutID);

            return userWorkPlan;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            WorkoutPlan userWorkPlan = entity as WorkoutPlan;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@userID", userWorkPlan.User.ID);
            command.Parameters.AddWithValue("@WorkoutID", userWorkPlan.Workout.ID);
            command.Parameters.AddWithValue("@day", userWorkPlan.Day);
            command.Parameters.AddWithValue("@id", userWorkPlan.ID);
        }

        public int Insert(WorkoutPlan userWorkPlan)
        {
            command.CommandText = "INSERT INTO tblUserWorkPlan " +
                "(UserID, WorkoutID) " +
                "VALUES (@UserID, @WorkoutID)";
            LoadParameters(userWorkPlan);
            return ExecuteCRUD();
        }
        public int Update(WorkoutPlan userWorkPlan)
        {
            command.CommandText = "UPDATE tblUserWorkPlan SET UserID = @UserID, WorkoutID = @WorkoutID, " +
                "WHERE GameID = @WorkoutID AND UserID = @UserID";
            LoadParameters(userWorkPlan);
            return ExecuteCRUD();
        }
        public int Delete(WorkoutPlan userWorkPlan)
        {
            command.CommandText = "DELETE FROM tblUserWorkPlan WHERE UserID = @UserID AND WorkoutID = @WorkoutID";
            LoadParameters(userWorkPlan);
            return ExecuteCRUD();
        }

        public WorkoutPlanList GetUserWorkoutPlans(User user)
        {
            command.CommandText = $"SELECT * FROM tblUserWorkPlan WHERE UserID = {user.ID}";
            WorkoutPlanList workouts = new WorkoutPlanList(ExecuteCommand());
            return workouts;
        }

    }
}
