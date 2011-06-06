﻿using System.Collections.Generic;
using System.Linq;
using Fake;
using Machine.Specifications;

namespace Test.FAKECore
{
    public class when_normalizing_version
    {
        It should_remove_the_last_version_if_it_is_empty =
            () => StringHelper.NormalizeVersion("0.1.2.0").ShouldEqual("0.1.2");

        It should_remove_the_last_two_versions_if_they_are_empty =
            () => StringHelper.NormalizeVersion("0.1.0.0").ShouldEqual("0.1");

        It should_not_remove_the_last_version_if_it_is_not_empty =
            () => StringHelper.NormalizeVersion("0.1.2.5").ShouldEqual("0.1.2.5");
    }

    public class when_using_string_helper
    {
        It should_not_separate_empty_text =
            () => StringHelper.separated("test", new List<string>())
                      .ShouldBeEmpty();

        It should_read_the_test_file =
            () => StringHelper.ReadFile(@"TestData\AllObjects.txt")
                      .Count().ShouldEqual(3578);

        It should_separate_one_line =
            () => StringHelper.separated("test", new List<string> {"first"})
                      .ShouldEqual("first");

        It should_separate_three_lines =
            () => StringHelper.separated("-", new List<string> {"first", "second", "third"})
                      .ShouldEqual("first-second-third");

        It should_separate_three_lines_with_line_ends =
            () => StringHelper.toLines(new List<string> {"first", "second", "third"})
                      .ShouldEqual("first\r\nsecond\r\nthird");

        It should_separate_two_lines_with_blank =
            () => StringHelper.separated(" ", new List<string> {"first", "second"})
                      .ShouldEqual("first second");
    }
}