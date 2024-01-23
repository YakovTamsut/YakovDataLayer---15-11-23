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
        protected int difficulty;
        protected ExerciseList exercises;


        public string Type { get { return type; } set { type = value; } }
        [DataMember]
        public int Difficulty { get { return difficulty; } set { difficulty=value; } }
        [DataMember]
        public ExerciseList Exercises { get { return exercises; } set { exercises =value; } }
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
