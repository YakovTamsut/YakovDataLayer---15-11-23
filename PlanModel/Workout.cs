using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Workout : BaseEntity
    {
        protected string type;
        protected string duration;
        protected ExerciseInWorkOutList exInWorkout;

        [DataMember]
        public string Type { get { return type; } set { type = value; } }
        [DataMember]
        public string Duration { get { return duration; } set { duration = value; } }
        [DataMember]
        public ExerciseInWorkOutList ExInWorkout { get { return exInWorkout; } set { exInWorkout = value; } }
    }

    [CollectionDataContract]
    public class WorkoutList : List<Workout>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public WorkoutList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public WorkoutList(IEnumerable<Workout> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public WorkoutList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Workout>().ToList()) { }
    }
}
