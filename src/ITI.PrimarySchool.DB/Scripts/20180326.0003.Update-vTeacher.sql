alter view iti.vTeacher
as
    select
        TeacherId = t.TeacherId,
        FirstName = t.FirstName,
        LastName = t.LastName,
		Presence = t.Presence
    from iti.tTeacher t
    where t.TeacherId <> 0;