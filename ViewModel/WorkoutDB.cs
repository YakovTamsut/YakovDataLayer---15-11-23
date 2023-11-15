using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorkoutDB:BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Workout() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Workout workout = entity as Workout;
            workout.ID = int.Parse(reader["id"].ToString());
            workout.Type = reader["type"].ToString();
            workout.Difficulty = int.Parse(reader["difficulty"].ToString());
            return workout;
        }
        public WorkoutList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblWorkout";
            WorkoutList list = new WorkoutList(ExecuteCommand());
            return list;
        }
        public Workout SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblWorkout WHERE id=" + id;
            WorkoutList list = new WorkoutList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Workout workout = entity as Workout;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", workout.ID);
            command.Parameters.AddWithValue("@firstName", workout.Type);
            command.Parameters.AddWithValue("@lastName", workout.Difficulty);
        }
        public int InsertWorkout(Workout workout)
        {
            command.CommandText = "INSERT INTO TblWorkouts (type,difficulty) VALUES (@type,@difficulty)";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
        public int UpdateWorkout(Workout workout)
        {
            command.CommandText = "UPDATE TblWorkouts SET type = @type,difficulty = @difficulty WHERE ID = @ID";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
        public int DeleteWorkout(Workout workout)
        {
            command.CommandText = "DELETE FROM TblWorkouts WHERE ID = @ID";
            LoadParameters(workout);
            return ExecuteCRUD();
        }
    }
}
