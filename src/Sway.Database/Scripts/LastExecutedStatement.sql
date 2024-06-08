SELECT txt.text,
       qp.query_plan,
       req.cpu_time,
       req.logical_reads,
       req.writes
FROM sys.dm_exec_requests req
    CROSS APPLY sys.dm_exec_query_plan(req.plan_handle) qp
    CROSS APPLY sys.dm_exec_sql_text(req.plan_handle) txt;
