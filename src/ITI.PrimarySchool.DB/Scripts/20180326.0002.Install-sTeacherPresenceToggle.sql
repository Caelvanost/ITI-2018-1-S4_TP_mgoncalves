create procedure iti.sTeacherPresenceToggle
(
	@TeacherId int
)
as
begin
	set transaction isolation level serializable;
	begin tran;

	if not exists(select * from iti.tTeacher t where t.TeacherId = @TeacherId)
	begin
		rollback;
		return 1;
	end;

	if ((select t.Presence from iti.tTeacher t where t.TeacherId = @TeacherId) = 0)
	begin
		update iti.tTeacher set Presence = 1 where TeacherId = @TeacherId;
		commit;
		return 0;
	end;

	else if ((select t.Presence from iti.tTeacher t where t.TeacherId = @TeacherId) = 1)
	begin
		update iti.tTeacher set Presence = 0 where TeacherId = @TeacherId;
		commit;
		return 0;
	end;

	else
	begin
		rollback;
		return 2;
	end;

end;