using System;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork(ProjectsEnum.SpeedTest, SubProjectsEnum.CollectionFindElementTest);
        }

        public static void DoWork(ProjectsEnum project, SubProjectsEnum subProject)
        {
            switch (project)
            {
                case ProjectsEnum.CrudeNode:
                    {
                        CrudNode.Work.DoWork();
                        return;
                    }
                case ProjectsEnum.PostfixNotation:
                    {
                        PostfixNotation.PostfixNotationExpression postfixNotation = new PostfixNotation.PostfixNotationExpression();
                        var result = postfixNotation.Calculate("2+3-(4*6)");
                        Console.WriteLine(result.Item2 ?? result.Item1?.ToString() ?? "Ошибка");
                        return;
                    }
                case ProjectsEnum.SpeedTest:
                    {
                        switch (subProject) {
                            case SubProjectsEnum.CollectionTest:
                                {
                                    SpeedTest.CollectionTest.DoWork();
                                    return;
                                }
                            case SubProjectsEnum.ClassStructTest:
                                {
                                    SpeedTest.ClassStructTest.DoWork();
                                    return;
                                }
                            case SubProjectsEnum.CollectionFindElementTest:
                                {
                                    SpeedTest.CollectionFindElementTest.DoWork();
                                    return;
                                }
                            default: break;
                        }
                        return;
                    }
                default:
                    break;
            }
        }
    }
}