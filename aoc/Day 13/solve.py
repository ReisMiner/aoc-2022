import json
import sys


# 3689 too low
# 5560 too low

def solve_packet(l, r):
    for h in range(0, len(l)):
        if h >= len(r):
            return -1
        if isinstance(l[h], int) and isinstance(r[h], int):
            if l[h] < r[h]:
                # correct order
                print(f"W {l[h], r[h]}")
                return 1
            elif l[h] > r[h]:
                # wrong order
                print(f"L {l[h], r[h]}")
                return -1
        elif isinstance(l[h], list):
            if isinstance(r[h], list):
                # both vals are lists
                res = solve_packet(l[h], r[h])
                if res != 0:
                    return res
            else:
                # only left is list
                res = solve_packet(l[h], [r[h]])
                if res != 0:
                    return res
        else:
            # only right is list
            res = solve_packet([l[h]], r[h])
            if res != 0:
                return res

    if len(l) == len(r):
        print(f"L late {l, r}")
        return 0
    print(f"W late {l, r}")
    return 1


if __name__ == '__main__':
    lines = sys.stdin.read().split("\n")
    packets = []
    for l in lines:
        if l != "":
            packets.append(json.loads(l))

    total = 0
    c = 1
    for i, left in enumerate(packets, start=1):
        if i % 2 == 0:
            continue
        right = packets[i]
        if solve_packet(left, right) == 1:
            total += c
        c += 1

    print(total)
