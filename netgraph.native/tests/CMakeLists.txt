include_directories(
    include
    $(PROJECT_SOURCE_DIR)/src
    )


add_executable(misc_tests_exe misc_tests.c)
add_executable(netgraph_tests_exe netgraph_tests.c)

target_link_libraries(
        netgraph_tests_exe
        NetgraphNative
    )

add_test(misc_tests misc_tests_exe)
add_test(netgraph_tests netgraph_tests_exe)
