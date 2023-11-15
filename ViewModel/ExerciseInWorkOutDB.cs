using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ExerciseInWorkOutDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ExerciseInWorkOut exinworkout = entity as ExerciseInWorkOut;
            exinworkout.ID=int.Parse(reader["id"].ToString());
            exinworkout.RepRange = reader["repRange"].ToString();
            WorkoutDB workoutDB = new WorkoutDB();
            exinworkout.Workout = workoutDB.SelectById(int.Parse(reader["workoutID"].ToString()));
            ExerciseDB exerciseDB = new ExerciseDB();
            exinworkout.Exercise = exerciseDB.SelectById(int.Parse(reader["exercisesID"].ToString()));
            return exinworkout;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            ExerciseInWorkOut exinworkout = entity as ExerciseInWorkOut;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", exinworkout.ID);
            command.Parameters.AddWithValue("@repRange", exinworkout.RepRange);
            command.Parameters.AddWithValue("@workoutID", exinworkout.Workout.ID);
            command.Parameters.AddWithValue("@exercisesID", exinworkout.Exercise.ID);
        }

        protected override BaseEntity NewEntity()
        {
            return new ExerciseInWorkOut();
        }

        public ExerciseInWorkOutList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblExInWorkout";
            ExerciseInWorkOutList list = new ExerciseInWorkOutList(ExecuteCommand());
            return list;
        }
        public ExerciseInWorkOut SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblExInWorkout WHERE id=" + id;
            ExerciseInWorkOutList list = new ExerciseInWorkOutList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int InsertWorkout(Workout workout)
        {
            command.CommandText = "INSERT INTO tblExInWorkout (repRange,workoutID,exercisesID) VALUES (@repRange,@workoutID,@exercisesID)";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
        public int UpdateWorkout(Workout workout)
        {
            command.CommandText = "UPDATE tblExInWorkout SET repRange = @repRange,workoutID = @workoutID,exercisesID = @exercisesID WHERE ID = @ID";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
        public int DeleteWorkout(Workout workout)
        {
            command.CommandText = "DELETE FROM tblExInWorkout WHERE ID = @ID";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
    }
}
