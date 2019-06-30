using System;

namespace CustomListView
{
    class Subject
    {
        public String subjectName;
        public int subjectImage;
        public String subjectType;

        public Subject(String mName, int mImage, String mType)
        {
            this.subjectName = mName;
            this.subjectImage = mImage;
            this.subjectType = mType;
        }

    }
}