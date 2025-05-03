# -*- coding: utf-8 -*-
import heapq

def read_adjacency_matrix(filename):
    matrix = []
    with open(filename, 'r', encoding='utf-8') as file:
        for line in file:
            row = list(map(int, line.split())) 
            matrix.append(row)
    return matrix

def prim_mst(matrix):
    n = len(matrix)  
    selected = [False] * n 
    min_weight = [float('inf')] * n  
    min_weight[0] = 0 
    parent = [-1] * n  
    total_weight = 0 
    mst_edges = [] 

    for i in range(n):  
        u = -1
        for v in range(n):
            if not selected[v] and (u == -1 or min_weight[v] < min_weight[u]):
                u = v

        selected[u] = True 
        total_weight += min_weight[u] 

        if parent[u] != -1:
            mst_edges.append((parent[u], u, min_weight[u]))

        for v in range(n):
            if matrix[u][v] > 0 and not selected[v] and matrix[u][v] < min_weight[v]:
                min_weight[v] = matrix[u][v]
                parent[v] = u  

    return total_weight, mst_edges


def main():
    filename = "g21.txt"
    matrix=read_adjacency_matrix(filename)

    total_weight, mst_edges = prim_mst(matrix)
    print("\nМинимальный вес остовного дерева:", total_weight)
    print("Рёбра MST:")
    for u, v, w in mst_edges:
        print(f"{u} - {v} (вес {w})")


if __name__ == "__main__":
    main()
