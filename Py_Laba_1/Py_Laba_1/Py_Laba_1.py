import sys
import locale


sys.stdout.reconfigure(encoding='utf-8')
locale.setlocale(locale.LC_ALL, 'ru_RU.UTF-8')

def read_adjacency_matrix(filename):
    matrix = []
    with open(filename, 'r', encoding='utf-8') as file:
        for line in file:
            row = list(map(int, line.split())) 
            matrix.append(row)
    return matrix

def make_undirected(matrix):
    size = len(matrix)
    for i in range(size):
        for j in range(i + 1, size):  
            if matrix[i][j] > 0 or matrix[j][i] > 0: 
                matrix[i][j] = matrix[j][i] = 1
                # max_weight = max(matrix[i][j], matrix[j][i])  # Берём наибольший вес
                # matrix[i][j] = matrix[j][i] = max_weight  # Делаем ребро двусторонним
    return matrix

def adjacency_matrix_to_list(matrix):
    adjacency_list = {i: [] for i in range(len(matrix))}
    for i in range(len(matrix)):
        for j in range(len(matrix[i])):
            if matrix[i][j] > 0:  
                adjacency_list[i].append(j)  # Добавляем только вершину
    return adjacency_list


def dfs(graph, start, visited=None, path=None):
    if visited is None:
        visited = set()
    if path is None:
        path = []
        
    visited.add(start)
    path.append(start)
    
    for neighbor in graph[start]:
        if neighbor not in visited:
            dfs(graph, neighbor, visited, path)
    
    return path

def multiplicationMatrix(first_matrix):
    #ok=True
    new_matrix = [row[:] for row in first_matrix]
    for k in range (len(first_matrix)):
        for i in range (len(first_matrix)):
            for j in range (len(first_matrix)):
                #fgfgf=new_matrix[i][j] or (new_matrix[i][k] and new_matrix[k][j])
                new_matrix[i][j] = new_matrix[i][j] or (new_matrix[i][k] and new_matrix[k][j])

    return new_matrix




def findComponentDFS(filename):
    #filename = "test.txt" 
    adjacency_matrix = read_adjacency_matrix(filename)

    adjacency_matrix = make_undirected(adjacency_matrix)

    adjacency_list = adjacency_matrix_to_list(adjacency_matrix)

    print("Матрица смежности:")
    for row in adjacency_matrix:
        print(row)

    # print("\nСписок смежности:")
    # for key, value in adjacency_list.items():
    #     print(f"{key}: {value}")

    print("\nКомпоненты связности:")
    path = []
    count = 1
    for i in range(len(adjacency_matrix)):
        if i not in path:
            way = dfs(adjacency_list, i)
            print(f"Компонента {count}: {way}")
            path += way
            count += 1


def findComponentMatrix(filename):
    # Чтение матрицы смежности
    #filename = "test.txt"  
    adjacency_matrix = read_adjacency_matrix(filename)

    # Преобразуем в неориентированный граф
    adjacency_matrix = make_undirected(adjacency_matrix)

    # Вывод матрицы для проверки
    print("Матрица смежности:")
    for row in adjacency_matrix:
        print(row)

    print("Матрица достижимости:")
    reachability_matrix=multiplicationMatrix(adjacency_matrix)
    for row in reachability_matrix:
        print (row)



while (1):
    

    print ("\nВведите неоходимую задачу:")
    print("1 найти количество и состав компонент связностей, обходом в глубину")
    print("2 получение матрицы достижимости")
    print("3 выбрать номер теста")

    task=int(input())
    if (task==1):
        findComponentDFS(filename)
    elif (task==2):
        findComponentMatrix(filename)
    elif (task==3):
        test = int (input( "\nBыберите номер теста: 1, 2, 3, 4 "))
        if (test==1):
            filename = "test1.txt"
        elif (test==2):
            filename = "test2.txt"
        elif (test==3):
            filename = "test3.txt"
        elif (test==4):
            filename = "test4.txt"
    else:
        break
