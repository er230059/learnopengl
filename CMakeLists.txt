cmake_minimum_required(VERSION 3.10)

# 專案名稱與 C++ 標準
project(MyProject)
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# 使用 clang++ 作為編譯器
set(CMAKE_CXX_COMPILER "clang++")

# 指定包含的標頭檔案路徑
include_directories(${CMAKE_SOURCE_DIR}/include)

# 指定連結的庫和框架 for macOS
set(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} \
    -framework CoreVideo \
    -framework OpenGL \
    -framework IOKit \
    -framework Cocoa \
    -framework Carbon")

# 指定來源檔案
set(SOURCES ${CMAKE_SOURCE_DIR}/main.cpp)

# GLAD 配置
add_library(glad glad.c)
set_target_properties(glad PROPERTIES LINKER_LANGUAGE C)
target_include_directories(glad PUBLIC include)

# 找到 glfw3
find_library(GLFW3_LIBRARY glfw3 REQUIRED)

# 建立可執行檔案
add_executable(MyExecutable ${SOURCES})

# 連結所需的庫
target_link_libraries(MyExecutable glad)
target_link_libraries(MyExecutable ${GLFW3_LIBRARY})
