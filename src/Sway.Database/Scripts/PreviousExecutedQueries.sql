-- Previously executed queries
SELECT TOP 5
    txt.[text],
    qp.query_plan,
    st.execution_count,
    st.min_logical_writes,
    st.max_logical_reads,
    st.total_logical_reads,
    st.total_elapsed_time,
    st.last_elapsed_time
FROM sys.dm_exec_query_stats st
    CROSS APPLY sys.dm_exec_query_plan(st.plan_handle) qp
    CROSS APPLY sys.dm_exec_sql_text(st.sql_handle) txt
ORDER BY (st.total_elapsed_time) DESC;