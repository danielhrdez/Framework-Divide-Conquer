import matplotlib.pyplot as plt
import pandas as pd

df = pd.read_csv('MergeQuickSort.csv')
merge_sort = df.iloc[:, 0]
quick_sort = df.iloc[:, 1]
sizes = df.iloc[:, 2]
plt.plot(sizes, merge_sort, label='Merge Sort')
plt.plot(sizes, quick_sort, label='Quick Sort')
plt.xlabel('Size')
plt.ylabel('Time (ms)')
plt.title('Merge Sort vs. Quick Sort')
plt.legend()
plt.savefig('MergeQuickSort.png')
